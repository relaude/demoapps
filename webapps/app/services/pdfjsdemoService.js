﻿app.service('pdfjsdemoService', function () {
    this.loadPDF = function () {
        PDFJS.workerSrc = 'Scripts/pdfjs/worker_loader.js';
        PDFJS.getDocument('Content/pdf/TS-chart.pdf').then(function (pdf) {
            // Using promise to fetch the page
            pdf.getPage(1).then(function (page) {
                var scale = 1.5;
                var viewport = page.getViewport(scale);

                //
                // Prepare canvas using PDF page dimensions
                //
                var canvas = document.getElementById('the-canvas');
                var context = canvas.getContext('2d');
                canvas.height = viewport.height;
                canvas.width = viewport.width;

                //
                // Render PDF page into canvas context
                //
                var renderContext = {
                    canvasContext: context,
                    viewport: viewport
                };
                page.render(renderContext);
            });
        });
    }
});