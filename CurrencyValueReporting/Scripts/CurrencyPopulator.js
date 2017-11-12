$(function () {
    $('.datepicker').datepicker();
});

var CurrencyName = "";

$("#PopulateGBPButton").click((x) => {
    CurrencyName = "gbp";
    GoToNextStep();
})

$("#PopulateUSDButton").click((x) => {
    CurrencyName = "usd";
    GoToNextStep();
})

$("#PopulateEURButton").click((x) => {
    CurrencyName = "eur";
    GoToNextStep();
})

$("#PopulateCHFButton").click((x) => {
    CurrencyName = "chf";
    GoToNextStep();
})

$("#DoPopulate").click((x) => {
    PopulateData();
})

function GoToNextStep() {
    $("#ChooseCurrencyDiv").hide();
    $("#ChooseDataRangeDiv").show();
}

function PopulateData() {
    var startDate = $('#DateFrom').val();
    var endDate = $('#DateTo').val();
    var selectedCurrency = $('#SelectedCurrency').val();

    $.get('/Home/PopulateDatabase', { dateFrom: startDate, dateTo: endDate, currency: CurrencyName });
}
