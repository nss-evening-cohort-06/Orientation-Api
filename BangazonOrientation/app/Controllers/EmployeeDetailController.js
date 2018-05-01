app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.hasComputer = true;

        $http.get(`/api/employees/${$routeParams.id}/computer`).then((result) => {
            if (result.data.ComputerID === undefined)
                return $scope.hasComputer = false;
            $scope.employee = result.data;

        });
    }
]);