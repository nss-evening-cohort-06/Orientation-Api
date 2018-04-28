app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/employees/${$routeParams.id}`).then((result) => {
            console.log(result);
            $scope.employee = result.data;
        });

    }
]);