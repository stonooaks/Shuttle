var viewModel = ko.mapping.fromJS(data);

$.getJSON("/Home/CalendarItems", data);
