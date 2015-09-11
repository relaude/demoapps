app.controller('NavbarController', function ($scope, $location) {
    $scope.getClass = function (path) {
        if ($location.path().substr(0, path.length) == path) {
            return true;
        } else {
            return false;
        }
    }

    $scope.getDropDownClass = function () {
        if ($location.path() == '/googleviewdoc') {
            return true;
        } else if ($location.path() == '/pdfjsdemo') {
            return true;
        } else {
            return false;
        }
    }
})

app.controller('jumbotronController', function (){

})

app.controller('demoController', function ($http, $scope, epplusService){

	$scope.readExcelFile = function (){
		epplusService.ReadExcelFile().then(function (response){
			$scope.content = response.data;
		});
	}

    $scope.uploadReadExcelFile = function (){
        var fd = new FormData();
        angular.forEach($scope.files, function (file){
            fd.append('file', file)
        });

        $http.post('/home/ReadExcelFile', fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type' : undefined }
        }).success(function (data, status, headers, config) {
            
            $scope.content = data;
        });
    }

})

app.controller('northwindController', function ($scope, northwindService, toaster){
    initialize();
    function initialize(){
        toaster.pop('wait', "Fetching Data", "Please wait...");
        northwindService.getAllProducts()
            .then(function(response){
                $scope.products = response.data;
                toaster.pop('success', "Message", "Data loaded.");
            });
    }
})

app.controller('chartController', function ($scope, chartService) {
    chartService.barchartdemo();
})

app.controller('pdfjsdemoController', function ($scope, pdfjsdemoService) {
    pdfjsdemoService.loadPDF(1);

    $scope.gotoPage = function () {
        pdfjsdemoService.loadPDF(parseInt($scope.pageNum));
    }
})

app.controller('pdfobjectdemoController', function ($scope, pdfobjectdemoService) {
    pdfobjectdemoService.embedPDF();
})