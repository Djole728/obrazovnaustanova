
/************************************************************************
* Multiple key fields extension for jTable *                                                   *
*************************************************************************/
(function ($) {
    //Reference to base object members
    var base = {
        _initializeFields: $.hik.jtable.prototype._initializeFields,
        _createFieldAndColumnList: $.hik.jtable.prototype._createFieldAndColumnList,
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

/************************************************************************
* PRIVATE FIELDS *
*************************************************************************/
        _keyFields: null, //Array of names of key fields of a record 

/************************************************************************
* CONSTRUCTOR AND INITIALIZING METHODS *
*************************************************************************/
        _initializeFields: function () {
            base._initializeFields.apply(this, arguments);

            //RS
            this._keyFields = [];

        },

        /* Fills _fieldList, _columnList arrays and sets _keyField variable.
        *************************************************************************/
        _createFieldAndColumnList: function () {
            var self = this;
            base._createFieldAndColumnList.apply(this, arguments);

            $.each(self.options.fields, function (name, props) {

                //RS if this is key -> add to keys array
                if (props.key == true) {
                    self._keyFields.push(name);
                }
            });
        },

        //RS multi-key
        getRowByKeys: function (keys) {
            for (var i = 0; i < this._$tableRows.length; i++) {
                if (keys == this._getKeyValuesOfRecord(this._$tableRows[i].data('record'))) {
                    return this._$tableRows[i];
                }
            }

            return null;
        },

        /* COMMON METHODS *******************************************************/

        //RS get key values of keys array
        _getKeyValuesOfRecord: function (record) {
            var ret = [];
            $.each(this._keyFields, function (k, v) {
                ret.push(record[v]);
            });
            return ret;
        },

        /* Updates a record on the table (optionally on the server also)
       *************************************************************************/
        updateRecord: function (options) {
            var self = this;
            options = $.extend({
                clientOnly: false,
                animationsEnabled: self.options.animationsEnabled,
                success: function () { },
                error: function () { }
            }, options);

            if (!options.record) {
                self._logWarn('options parameter in updateRecord method must contain a record property.');
                return;
            }

            //RS multi-key
            var keys = self._getKeyValuesOfRecord(options.record);
            if (keys == undefined || keys == null || keys.length < 1) {
                self._logWarn('options parameter in updateRecord method must contain a record that contains the key field property.');
                return;
            }
            //RS 
            var $updatingRow = self.getRowByKeys(keys);
            if ($updatingRow == null) {
                self._logWarn('Can not found any row by key: ' + keys);
                return;
            }

            if (options.clientOnly) {
                $.extend($updatingRow.data('record'), options.record);
                self._updateRowTexts($updatingRow);
                self._onRecordUpdated($updatingRow, null);
                if (options.animationsEnabled) {
                    self._showUpdateAnimationForRow($updatingRow);
                }

                options.success();
                return;
            }

            var completeEdit = function (data) {
                if (data.Result != 'OK') {
                    self._showError(data.Message);
                    options.error(data);
                    return;
                }

                $.extend($updatingRow.data('record'), options.record);
                self._updateRecordValuesFromServerResponse($updatingRow.data('record'), data);

                self._updateRowTexts($updatingRow);
                self._onRecordUpdated($updatingRow, data);
                if (options.animationsEnabled) {
                    self._showUpdateAnimationForRow($updatingRow);
                }

                options.success(data);
            };

            //updateAction may be a function, check if it is
            if (!options.url && $.isFunction(self.options.actions.updateAction)) {

                //Execute the function
                var funcResult = self.options.actions.updateAction($.param(options.record));

                //Check if result is a jQuery Deferred object
                if (self._isDeferredObject(funcResult)) {
                    //Wait promise
                    funcResult.done(function (data) {
                        completeEdit(data);
                    }).fail(function () {
                        self._showError(self.options.messages.serverCommunicationError);
                        options.error();
                    });
                } else { //assume it returned the creation result
                    completeEdit(funcResult);
                }

            } else { //Assume it's a URL string

                //Make an Ajax call to create record
                self._submitFormUsingAjax(
                    options.url || self.options.actions.updateAction,
                    $.param(options.record),
                    function (data) {
                        completeEdit(data);
                    },
                    function () {
                        self._showError(self.options.messages.serverCommunicationError);
                        options.error();
                    });

            }
        },

        /* Saves editing form to the server and updates the record on the table.
        *************************************************************************/
        _saveEditForm: function ($editForm, $saveButton) {
            var self = this;

            var completeEdit = function (data) {
                if (data.Result != 'OK') {
                    self._showError(data.Message);
                    self._setEnabledOfDialogButton($saveButton, true, self.options.messages.save);
                    return;
                }

                var record = self._$editingRow.data('record');

                self._updateRecordValuesFromForm(record, $editForm);
                self._updateRecordValuesFromServerResponse(record, data);
                self._updateRowTexts(self._$editingRow);

                self._$editingRow.attr('data-record-key', self._getKeyValueOfRecord(record));

                //RS
                self._$editingRow.attr('data-record-keys', self._getKeyValuesOfRecord(record));

                self._onRecordUpdated(self._$editingRow, data);

                if (self.options.animationsEnabled) {
                    self._showUpdateAnimationForRow(self._$editingRow);
                }

                self._$editDiv.dialog("close");
            };


            //updateAction may be a function, check if it is
            if ($.isFunction(self.options.actions.updateAction)) {

                //Execute the function
                var funcResult = self.options.actions.updateAction($editForm.serialize());

                //Check if result is a jQuery Deferred object
                if (self._isDeferredObject(funcResult)) {
                    //Wait promise
                    funcResult.done(function (data) {
                        completeEdit(data);
                    }).fail(function () {
                        self._showError(self.options.messages.serverCommunicationError);
                        self._setEnabledOfDialogButton($saveButton, true, self.options.messages.save);
                    });
                } else { //assume it returned the creation result
                    completeEdit(funcResult);
                }

            } else { //Assume it's a URL string

                //Make an Ajax call to update record
                self._submitFormUsingAjax(
                    self.options.actions.updateAction,
                    $editForm.serialize(),
                    function (data) {
                        completeEdit(data);
                    },
                    function () {
                        self._showError(self.options.messages.serverCommunicationError);
                        self._setEnabledOfDialogButton($saveButton, true, self.options.messages.save);
                    });
            }

        },

        /* Deletes a record from the table (optionally from the server also).
       *************************************************************************/
        deleteRecord: function (options) {
            var self = this;
            options = $.extend({
                clientOnly: false,
                animationsEnabled: self.options.animationsEnabled,
                url: self.options.actions.deleteAction,
                success: function () { },
                error: function () { }
            }, options);

            //RS multi-key
            if (options.keys == undefined || options.keys == null || option.keys < 1) {
                self._logWarn('options parameter in deleteRecord method must contain a key property.');
                return;
            }

            var $deletingRow = self.getRowByKeys(options.keys);
            if ($deletingRow == null) {
                self._logWarn('Can not found any row by key: ' + options.keys);
                return;
            }
            if (options.clientOnly) {
                self._removeRowsFromTableWithAnimation($deletingRow, options.animationsEnabled);
                options.success();
                return;
            }

            self._deleteRecordFromServer(
                    $deletingRow,
                    function (data) { //success
                        self._removeRowsFromTableWithAnimation($deletingRow, options.animationsEnabled);
                        options.success(data);
                    },
                    function (message) { //error
                        self._showError(message);
                        options.error(message);
                    },
                    options.url
                );
        },

    });
})(jQuery);

/************************************************************************
* DELETION extension for jTable                                         *
*************************************************************************/
(function ($) {
    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Performs an ajax call to server to delete record
       *  and removes row of the record from table if ajax call success.
       *************************************************************************/
        _deleteRecordFromServer: function ($row, success, error, url) {
            var self = this;

            var completeDelete = function (data) {
                if (data.Result != 'OK') {
                    $row.data('deleting', false);
                    if (error) {
                        error(data.Message);
                    }

                    return;
                }

                self._trigger("recordDeleted", null, { record: $row.data('record'), row: $row, serverResponse: data });

                if (success) {
                    success(data);
                }
            };

            //Check if it is already being deleted right now
            if ($row.data('deleting') == true) {
                return;
            }

            $row.data('deleting', true);

            var postData = {};
            postData[self._keyField] = self._getKeyValueOfRecord($row.data('record'));

            //RS multi-key
            var keyV = self._getKeyValuesOfRecord($row.data('record'));
            for (i = 0; i < keyV.length; i++) { postData[self._keyFields[i]] = keyV[i] }


            //deleteAction may be a function, check if it is
            if (!url && $.isFunction(self.options.actions.deleteAction)) {

                //Execute the function
                var funcResult = self.options.actions.deleteAction(postData);

                //Check if result is a jQuery Deferred object
                if (self._isDeferredObject(funcResult)) {
                    //Wait promise
                    funcResult.done(function (data) {
                        completeDelete(data);
                    }).fail(function () {
                        $row.data('deleting', false);
                        if (error) {
                            error(self.options.messages.serverCommunicationError);
                        }
                    });
                } else { //assume it returned the deletion result
                    completeDelete(funcResult);
                }

            } else { //Assume it's a URL string
                //Make ajax call to delete the record from server
                this._ajax({
                    url: (url || self.options.actions.deleteAction),
                    data: postData,
                    success: function (data) {
                        completeDelete(data);
                    },
                    error: function () {
                        $row.data('deleting', false);
                        if (error) {
                            error(self.options.messages.serverCommunicationError);
                        }
                    }
                });

            }
        },
    });
})(jQuery);


/************************************************************************
* SELECTING extension for jTable                                        *
*************************************************************************/
(function ($) {

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Stores Id's of currently selected records to _selectedRecordIdsBeforeLoad.
        *************************************************************************/
        _storeSelectionList: function () {
            var self = this;

            if (!self.options.selecting) {
                return;
            }

            self._selectedRecordIdsBeforeLoad = [];

            //RS multi-key 
            self._getSelectedRows().each(function () {
                self._selectedRecordIdsBeforeLoad.push(self._getKeyValuesOfRecord($(this).data('record')));
            });
        },

        /* Selects rows whose Id is in _selectedRecordIdsBeforeLoad;
        *************************************************************************/
        _restoreSelectionList: function () {
            var self = this;

            if (!self.options.selecting) {
                return;
            }

            var selectedRowCount = 0;

            //RS multi -key 

            for (var i = 0; i < self._$tableRows.length; ++i) {
                var recordId = self._getKeyValuesOfRecord(self._$tableRows[i].data('record'));
                if ($.inArray(recordId, self._selectedRecordIdsBeforeLoad) > -1) {
                    self._selectRows(self._$tableRows[i]);
                    ++selectedRowCount;
                }
            }

            if (self._selectedRecordIdsBeforeLoad.length > 0 && self._selectedRecordIdsBeforeLoad.length != selectedRowCount) {
                self._onSelectionChanged();
            }

            self._selectedRecordIdsBeforeLoad = [];
            self._refreshSelectAllCheckboxState();
        },


    });

})(jQuery);