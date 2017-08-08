function isNullOrEmpty(val) {
	if (typeof val !== 'undefined') {
		if (val.length > 0) {
			return false;
		}
	}

	return true;
}

function highLightErr(obj) {
	if (typeof obj !== 'undefined') {
		obj.css('border', '1px solid indianred');
	}
}

function deHighLightErr(obj) {
	if (typeof obj !== 'undefined') {
		obj.css('border', '1px solid #ccc');
	}
}

$(document).ready(function() {

	$('#frmBasicSearch').on('submit', function(event) {
		event.preventDefault();
		var keyword = $('#txtKeyword');
		if (isNullOrEmpty(keyword.val())) {
			highLightErr(keyword);
			return false;
		}

		deHighLightErr(keyword);
		return false;
		// call ajax
	});

	$('#btnAdvanceSearch').on('click', function(event) {
		$('#advanceSearchBox').fadeToggle('medium','linear');
	});

	$('.pageTab').on('click', 'a', function(event) {
		var type = $(this).data('type');
		var test = "test";
		switch (type) {
			case 0:
				test = "case 0";
				// ajax to get data
				break;
			case 1:
				test = "case 1";
				// ajax to get data
				break;
			case 2:
				test = "case 2";
				// ajax to get data
				break;
			case 3:
				test = "case 3";
				// ajax to get data
				break;
		}
		$('#contentHolder').text(test);
	});

	$('#prePageButton').on('click', function(event) {
		// ajax to get data
	});

	$('#nextPageButton').on('click', function(event) {
		// ajax to get data
	});

	$('#frmMaterialInfo').on('submit', function(event) {
		event.preventDefault();
		var name = $('#txtName');
		var unit = $('#txtUnit');
		var inventory = $('#txtInventory');
		var holder = $('#errMessageHolder');
		var errMes = "";
		var rs = true;

		if (isNullOrEmpty(name.val())) {
			errMes += "Name cannot be empty</br>";
			rs = false;
			highLightErr(name);
		} else {
			deHighLightErr(name);
		}

		if (isNullOrEmpty(unit.val()) || unit.val() < 0) {
			errMes += "Unit cannot be empty and must be a positive number</br>";
			rs = false;
			highLightErr(unit);
		} else {
			deHighLightErr(unit);
		}

		if (isNullOrEmpty(inventory.val()) || inventory.val() < 0) {
			errMes += "Inventory cannot be empty and must be a positive number</br>";
			rs = false;
			highLightErr(inventory);
		} else {
			deHighLightErr(inventory);
		}

		if (rs == true) {
			// call ajax
			holder.hide();
		} else {
			holder.empty();
			holder.append(errMes);
			holder.show();
		}
	});

	$('#frmMaterialCategoryInfo').on('submit', function(event) {
		event.preventDefault();
		var name = $('#txtName');
		var holder = $('#errMessageHolder');
		var errMes = "";
		var rs = true;

		if (isNullOrEmpty(name.val())) {
			errMes += "Name cannot be empty</br>";
			rs = false;
			highLightErr(name);
		} else {
			deHighLightErr(name);
		}

		if (rs == true) {
			// call ajax
			holder.hide();
		} else {
			holder.empty();
			holder.append(errMes);
			holder.show();
		}
	});

	$('#frmMaterialLogBasicSearch').on('submit', function(event) {
		event.preventDefault();
		var fromDate = $('#dtFromDate');
		var toDate = $('#dtToDate');
		var rs = true;

		if (fromDate.val() == "") {
			highLightErr(fromDate);
			rs = false;
		} else {
			deHighLightErr(fromDate);
		}

		if (toDate.val() == "") {
			highLightErr(toDate);
			rs = false;
		} else {
			var from = Date.parse(fromDate.val());
			var to = Date.parse(toDate.val());

			if (from > to) {
				var holder = $('#popupMes');
				holder.find('.modal-body').append("<p>From date must less than or equal to To date</p>");
			    holder.modal();
			    highLightErr(fromDate);
			    highLightErr(toDate);
			} else {
				deHighLightErr(fromDate);
				deHighLightErr(toDate);
			}
		}

		return rs;
	});

	$('#frmMaterialLogInfo').on('submit', function(event) {
		event.preventDefault();
		var date = $('#dtDate');
		var inventory = $('#txtInventory');
		var holder = $('#errMessageHolder');
		var errMes = "";
		var rs = true;

		if (date.val() == "") {
			errMes += "Date cannot be empty</br>";
			rs = false;
			highLightErr(date);
		} else {
			deHighLightErr(date);
		}

		if (isNullOrEmpty(inventory.val()) || inventory.val() < 0) {
			errMes += "Inventory cannot be empty and must be a positive number</br>";
			rs = false;
			highLightErr(inventory);
		} else {
			deHighLightErr(inventory);
		}

		if (rs == true) {
			// call ajax
			holder.hide();
		} else {
			holder.empty();
			holder.append(errMes);
			holder.css('color', 'red');
			holder.show();
		}
	});
});