$(function () {
	$('.edit-mode').hide();
	$('.editable td').on('dblclick', function () {
		//var tr = $(this).parents('tr:first');
		//tr.find('.edit-mode, .display-mode').toggle();
		changeToEdit($(this));
	});

	$(document).click(function () {
		$('.edit-mode').hide();
		$('.display-mode').show();
	});
	//$(".edit-mode").click(function (e) {
	//	e.stopPropagation();
	//});

	$('#btnSave').click(function (e) {
		e.preventDefault();
		var offer = new OfferDto($('#ID').val(), $('#Active').val(), $('#DateCreated').val(), $('#ClientID').val(), $('#ClientFirstName').val(), $('#ClientLastName').val(), $('#ClientEmail').val(), $('#ClientPhoneNumber').val(), $('#ClientTitle').val(), $('#DeliveryDate').val(), $('#Heading').val());
		var rows = $('#tblNotes').find('tbody:first').find('tr');//.find('.edit-mode');
		
		for (var i = 0; i < rows.length; i++) {
			var note = $(rows[i]).find('.note');
			var noteId = $(rows[i]).find('.id');
			var noteGuid = $(rows[i]).find('.guid');
			offer.OfferNotes.push(new OfferNoteDto(noteId.val(), true, noteGuid.val(), offer.ClientID, note.val(), offer.ID));
		}

		submitOffer(offer);
	});

	//$('.edit-mode').focusout(function (e) {
	//	var td = $(this).parents('td:first');
	//	td.find('.display-mode').text($(this).val());
	//});

	$('#btnNewNote').click(function (e) {
		var guid = createGuid();
		var templateRow = createNoteRow(guid);
		$('#tblNotes > tbody:last-child').append(templateRow);
		var templateRowTd = $('#tblNotes tr:last td');
		$(templateRowTd).on('dblclick', function () { changeToEdit($(templateRowTd)) });
		$(templateRowTd).find('.edit-mode').focus();
		e.stopPropagation();
	});
})

function createNoteRow(guid) {
	return "<tr><td><span class='display-mode' style='display: none;'></span><input id='" + guid + "' value='' type='text' class='edit-mode form-control note' style='' onclick='event.stopPropagation()' onfocusout=changeToDisplay($(this))><input style='display: none' value='' type='text' class='form-control id'><input style='display: none' type='text' class='form-control guid' value='" + guid + "'></td><td class='action-columns'><a class = 'glyphicon glyphicon-trash text-info' onclick='deleteRow($(this))' style='cursor: pointer;'></a></td></tr>";
}

function createGuid() {
	return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
		(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
	)
}

function changeToEdit(attr) {
	var tr = $(attr).parents('tr:first');
	tr.find('.edit-mode, .display-mode').toggle();
	tr.find('.edit-mode').focus().select();
}

function changeToDisplay(attr) {
	var td = $(attr).parents('td:first');
	td.find('.display-mode').text($(attr).val());
}

function deleteRow(attr) {
	var tr = $(attr).parents('tr:first');
	tr.remove();
}

function submitOffer(offer) {
	var form = $('#offerForm');
	var token = $('input[name="__RequestVerificationToken"]', form).val();
	$.ajax({
		type: 'POST',
		data: {
			__RequestVerificationToken: token,
			offerDto: offer
		}, 
		url: '/Offers/Edit/1',
		//contentType: 'application/json',
		//dataType: 'json',
		success: function (response) {
			alert('ok');
		},
		error: function (jqXHR, textStatus, errorThrown) {
			alert(errorThrown);
		}
	});
}

class OfferDto {

	constructor(ID, Active, DateCreated, ClientID, ClientFirstName, ClientLastName, ClientEmail, ClientPhoneNumber, ClientTitle, DeliveryDate, Heading) {
		this.ID = ID;
		this.Active = Active;
		this.DateCreated = DateCreated;
		this.ClientID = ClientID;
		this.ClientFirstName = ClientFirstName;
		this.ClientLastName = ClientLastName;
		this.ClientEmail = ClientEmail;
		this.ClientPhoneNumber = ClientPhoneNumber;
		this.ClientTitle = ClientTitle;
		this.DeliveryDate = DeliveryDate;
		this.Heading = Heading;
		this.OfferNotes = [];
	}

}

class OfferNoteDto {

	constructor(ID, Active, Guid, ClientID, Note, OfferID) {
		this.ID = ID;
		this.Active = Active;
		this.Guid = Guid;
		this.ClientID = ClientID;
		this.Note = Note;
		this.OfferID = OfferID;
	}

}

	//$('.save-book').on('click', function () {
	//    var tr = $(this).parents('tr:first');
	//    var bookId = $(this).prop('id');
	//    var title = tr.find('#Title').val();
	//    var authorId = tr.find('#AuthorId').val();
	//    var categoryId = tr.find('#CategoryId').val();
	//    var isbn = tr.find('#ISBN').val();
	//    $.post(
	//        '/EditBook',
	//        { BookId: bookId, Title: title, AuthorId: authorId, CategoryId: categoryId, ISBN: isbn },
	//        function (book) {
	//            tr.find('#title').text(book.Title);
	//            tr.find('#authorname').text(book.AuthorName);
	//            tr.find('#category').text(book.Category);
	//            tr.find('#isbn').text(book.ISBN);
	//        }, "json");
	//    tr.find('.edit-mode, .display-mode').toggle();
	//});