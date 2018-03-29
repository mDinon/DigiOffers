$(document).ready(function () {
	$('.tblOffers').DataTable({
		searching: false,
		paging: false,
		info: false,
		language: {
			"search": "Pretraži:",
			"lengthMenu": "Prikaži _MENU_ zapisa po stranici",
			"zeroRecords": "Nema zapisa",
			"info": "Strana _PAGE_ od _PAGES_",
			"infoEmpty": "Nema zapisa",
		}
	});
});