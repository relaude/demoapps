var app = angular.module('webapps', ['ngRoute','ngAnimate','toaster'])

app.config(function ($routeProvider) {
	
	$routeProvider
		.when('/jumbotron',{
			controller: 'jumbotronController',
			templateUrl: '/app/partials/jumbotron.html'
		})

		.when('/demo',{
			controller: 'demoController',
			templateUrl: '/app/partials/demo.html'
		})

		.when('/northwind',{
			controller: 'northwindController',
			templateUrl: '/app/partials/northwind.html'
		})

        .when('/d3chart', {
            controller: 'chartController',
            templateUrl: '/app/partials/d3chart.html'
        })

        .when('/googleviewdoc', {
            controller: 'pdfobjectdemoController',
            templateUrl: '/app/partials/googledocview.html'
        })

        .when('/pdfjsdemo', {
            controller: 'pdfjsdemoController',
            templateUrl: '/app/partials/pdfjsdemo.html'
        })

		.otherwise({ redirectTo: '/jumbotron' });

})
