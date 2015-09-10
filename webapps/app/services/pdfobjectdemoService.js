app.service('pdfobjectdemoService', function () {
    this.embedPDF = function () {
        var myPDF = new PDFObject({

            url: 'Content/pdf/TS-chart.pdf'

        }).embed('pdf');
    }
});