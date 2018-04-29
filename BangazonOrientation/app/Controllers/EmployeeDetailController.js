app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/employees/${$routeParams.id}`).then((result) => {
            $scope.employee = result.data;
        });
        //$http.get(`/api/`)
    }
]);