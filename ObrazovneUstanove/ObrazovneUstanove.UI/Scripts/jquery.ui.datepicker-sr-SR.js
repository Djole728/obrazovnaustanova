/* Serbian i18n for the jQuery UI date picker plugin. */
	jQuery(function($){
	        $.datepicker.regional['sr-Latn-BA'] = {
	                closeText: 'Zatvori',
	                prevText: 'Prethodni',
	                nextText: 'Sljedeći',
	                currentText: 'Danas',
	                monthNames: ['Januar','Februar','Mart','April','Maj','Jun',
	                'Jul','Avgust','Septembar','Oktobar','Novembar','Decembar'],
	                monthNamesShort: ['Jan','Feb','Mar','Apr','Maj','Jun',
	                'Jul','Avg','Sep','Okt','Nov','Dec'],
	                dayNames: ['Nedjelja','Ponedjeljak','Utorak','Srijeda','Četvrtak','Petak','Subota'],
	                dayNamesShort: ['Ned','Pon','Uto','Sre','Čet','Pet','Sub'],
	                dayNamesMin: ['Ne','Po','Ut','Sr','Če','Pe','Su'],
	                weekHeader: 'Sed',
	                dateFormat: 'dd.mm.yy',
	                firstDay: 1,
	                isRTL: false,
	                showMonthAfterYear: false,
	                yearSuffix: ''};
	        $.datepicker.setDefaults($.datepicker.regional['sr-Latn-BA']);
	});