/************************************************************************
* DECIMAL TYPE extension for jTable *
*************************************************************************/
(function ($) {

    //Reference to base object members
    var base = {
        _getDisplayTextForRecordField: $.hik.jtable.prototype._getDisplayTextForRecordField,
        _getValueForRecordField: $.hik.jtable.prototype._getValueForRecordField
    };

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /************************************************************************
        * PRIVATE METHODS                                                       *
        *************************************************************************/

        /* Format decimal number
        *************************************************************************/
        _getValueForDecimalField: function (fieldValue) {
            return fieldValue != null ? number_format(fieldValue, 2, ',', '') : null;
        },


        /************************************************************************
        * OVERRIDED METHODS
        *************************************************************************/

        /* Gets text for a field of a record according to it's type.
        *************************************************************************/
        _getDisplayTextForRecordField: function (record, fieldName) {
            var field = this.options.fields[fieldName];
            var fieldValue = record[fieldName];

            //if this is a custom field, call display function
            if (field.display) {
                return field.display({ record: record });
            }

            if (field.type == 'date') {
                return this._getDisplayTextForDateRecordField(field, fieldValue);
            } else if (field.type == 'checkbox') {
                return this._getCheckBoxTextForFieldByValue(fieldName, fieldValue);
            } else if (field.options) { //combobox or radio button list since there are options.
                var options = this._getOptionsForField(fieldName, {
                    record: record,
                    value: fieldValue,
                    source: 'list',
                    dependedValues: this._createDependedValuesUsingRecord(record, field.dependsOn)
                });
                return this._findOptionByValue(options, fieldValue).DisplayText;

            } else if (field.type == 'decimal') {
                return this._getValueForDecimalField(fieldValue);
            } else { //other types
                return fieldValue;
            }
        },


        /* Gets text for a field of a record according to it's type.
        *************************************************************************/
        _getValueForRecordField: function (record, fieldName) {
            var field = this.options.fields[fieldName];
            var fieldValue = record[fieldName];
            if (field.type == 'date') {
                return this._getDisplayTextForDateRecordField(field, fieldValue);
            } else if (field.type == 'decimal') {
                return this._getValueForDecimalField(fieldValue);
            } else {
                return fieldValue;
            }
        }

    });

})(jQuery);