app.service('northwindService', function ($http) {
	this.getAllProducts = function(){
		var promise = $http({
			method: 'GET',
			url: '/api/service',
			data: {},
			headers: {}
		}).success(function (data, status, headers, config) {
			return data;
		});

		return promise;
	};
})