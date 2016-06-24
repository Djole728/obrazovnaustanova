/************************************************************************
* Spinner extension for jTable *
*************************************************************************/
(function ($) {

    //extension members
    $.extend(true, $.hik.jtable.prototype, {

        /* Creates a div to block UI while jTable is busy.
       *************************************************************************/
        _createBusyPanel: function () {
            this._$busyDiv = $('<i></i>').addClass('fa fa-spinner fa-spin table-spinner').prependTo(this._$mainContainer);
            this._$busyMessageDiv = $('<span></span>').addClass('fa fa-info').prependTo(this._$mainContainer);
            this._jqueryuiThemeAddClass(this._$busyMessageDiv, 'ui-widget-header');
            this._hideBusy();
        },

        /* BUSY PANEL ***********************************************************/

        /* Shows busy indicator and blocks table UI.
        * TODO: Make this cofigurable and changable
        *************************************************************************/
        _setBusyTimer: null,
        _showBusy: function (message, delay) {
            var self = this;  //

            //Show a transparent overlay to prevent clicking to the table
            self._$busyDiv
                .addClass('jtable-busy-panel-background-invisible')
                .show();

            var makeVisible = function () {
                self._$busyDiv.removeClass('jtable-busy-panel-background-invisible');
            };

            if (delay) {
                if (self._setBusyTimer) {
                    return;
                }

                self._setBusyTimer = setTimeout(makeVisible, delay);
            } else {
                makeVisible();
            }
        },
    });
})(jQuery);