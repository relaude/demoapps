app.service('epplusService', function ($http) {
	
	this.ReadExcelFile = function(){
		var promise = $http({
            method: 'POST',
            url: '/home/ReadExcelFile',
            data: JSON.stringify({ 
        		filePath: "C:\Program Files\Common Files\Microsoft Shared\DevServer\10.0\ExampleData.xlsx" ,
        		fromRow: 5,
        		fromColumn: 1
        	}),
        	headers: { 'Content-Type': 'application/json; charset=utf-8' }
        }).success(function (data, status, headers, config) {
            
            return data;
        });

        return promise;
	};

})