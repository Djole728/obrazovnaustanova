
/************************************************************************
* BUTTON TOOLTIP extension for jTable                                           *
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _onRecordsLoaded: $.hik.jtable.prototype._onRecordsLoaded
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /************************************************************************
        * OVERRIDED METHODS                                                     *
        *************************************************************************/

        /* Overrides _onRecordsLoaded method to use bootstrap tooltips
        *************************************************************************/
        _onRecordsLoaded: function (data) {
            base._onRecordsLoaded.apply(this, arguments);
            this._initTooltip();
        },

        /************************************************************************
        * PRIVATE METHODS                                                       *
        *************************************************************************/

        /* Initialize tooltip on command buttons jtable-command-button
   *************************************************************************/
        _initTooltip: function () {
            var btn = $('.jtable-command-column button');
            btn.attr('data-placement', 'top');
            btn.attr('data-rel', 'tooltip');
            //btn.attr('data-original-title', btn.attr('title'));

            $('[data-rel=tooltip]').tooltip();
        },
    });

})(jQuery);




/************************************************************************
*AUTO PROPETIES (generete column from autoProperties option) extension for jTable                                           *
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _create: $.hik.jtable.prototype._create,
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {


        /************************************************************************
     * CONSTRUCTOR AND INITIALIZING METHODS                                  *
     *************************************************************************/

        /* Overrides base._create method to do autoProperties-specific constructions.
        *************************************************************************/
        _create: function () {
            if (this.options.autoProperties) {
                var self = this;
                $.each(self.options.autoProperties.split(","), function (index, item) {
                    self.options.fields[item] =
                    {
                        create: true,
                        edit: true,
                        list: false,
                        type: 'hidden',
                        defaultValue: $('#' + item).val(),
                    };
                });
            }
            base._create.apply(this, arguments);
        },
    });

})(jQuery);


/************************************************************************
* Default date format extension for jTable *                                                  
*************************************************************************/
(function ($) {
    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /************************************************************************
        * DEFAULT OPTIONS / EVENTS *
        *************************************************************************/
        options: {
            defaultDateFormat: 'dd.mm.yy',
        },
    });

})(jQuery);



/************************************************************************
*READONLY MOD (jTable only have list action) extension for jTable                                           *
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _create: $.hik.jtable.prototype._create,
        _createToolBar: $.hik.jtable.prototype._createToolBar,
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /************************************************************************
     * CONSTRUCTOR AND INITIALIZING METHODS                                  *
     *************************************************************************/

        /* Overrides base._create method to do readonly-specific constructions.
        *************************************************************************/
        _create: function () {
            if (this.options.readOnly === 'True' || this.options.readOnly === true) {
                this.options.actions = { listAction: this.options.actions.listAction };
            }
            base._create.apply(this, arguments);
        },

        _createToolBar: function () {
            if (this.options.readOnly == undefined || this.options.readOnly === 'False' || this.options.readOnly === false) {

                base._createToolBar.apply(this, arguments);
            }
        }
    });

})(jQuery);



/************************************************************************
*DATETIMEPICKER CHANGE YEAR AND MONTH (jTable only have list action) extension for jTable                                           *
*************************************************************************/
(function ($) {
    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Creates a date input for a field.
        *************************************************************************/
        _createDateInputForField: function (field, fieldName, value) {
            var $input = $('<input class="' + field.inputClass + '" id="Edit-' + fieldName + '" type="text" name="' + fieldName + '"></input>');
            if (value != undefined) {
                $input.val(value);
            }

            var displayFormat = field.displayFormat || this.options.defaultDateFormat;
            $input.datepicker({ dateFormat: displayFormat, changeYear: true, changeMonth: true, yearRange: '1900:+0' });
            return $('<div />')
                .addClass('jtable-input jtable-date-input')
                .append($input);
        },
    });
})(jQuery);

/************************************************************************
* EDIT AND DELETE RECORD FILTER extension for jTable                                                 *
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _addCellsToRowUsingRecord: $.hik.jtable.prototype._addCellsToRowUsingRecord
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Overrides base method to add a 'edit command cell' to a row.
       *************************************************************************/
        _addCellsToRowUsingRecord: function ($row) {
            var self = this;
            var disableRowEdit = this.options.enableRowEdit && !this.options.enableRowEdit($row.data('record'));
            var disableRowDelete = this.options.enableRowDelete && !this.options.enableRowDelete($row.data('record'));
            var updateAction = self.options.actions.updateAction;
            var deleteAction = self.options.actions.deleteAction;

            if (disableRowEdit) {
                self.options.actions.updateAction = undefined;
            }
            if (disableRowDelete) {
                self.options.actions.deleteAction = undefined;
            }

            base._addCellsToRowUsingRecord.apply(this, arguments);

            if (disableRowEdit) {
                self.options.actions.updateAction = updateAction;
                if (self.options.actions.deleteAction) {
                    $row.find("td:last").before('<td class="jtable-command-column"></td>');
                }
                else {
                    $('<td></td>')
                      .addClass('jtable-command-column')
                      .appendTo($row);
                }
            }
            if (disableRowDelete) {
                self.options.actions.deleteAction = deleteAction;
                $('<td></td>')
                  .addClass('jtable-command-column')
                  .appendTo($row);
            }
        },
    });
})(jQuery);
/************************************************************************
*SCROLLABLE TABLE 
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _createTable: $.hik.jtable.prototype._createTable,
        _createBottomPanel: $.hik.jtable.prototype._createBottomPanel
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Overrides base method to add a 'edit command cell' to a row.
       *************************************************************************/
        _createTable: function ($row) {
            var self = this;
            base._createTable.apply(this, arguments);

            this._$table.wrap("<div class='table-responsive'></div>")
            this._$table.addClass('table');

        },
        _createBottomPanel: function() {
            var self = this;
            base._createBottomPanel.apply(this, arguments);

            this._$bottomPanel.detach();
            this._$bottomPanel.insertAfter(this._$table.parent());
        }
    });
})(jQuery);














