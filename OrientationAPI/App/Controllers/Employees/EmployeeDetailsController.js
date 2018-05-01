app.controller("Employees/EmployeeDetailsController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {

        $scope.header = "Employee Details";

        $http.get(`api/employees/employee-details/${$routeParams.id}`).then(function (result) {
            $scope.employee = result.data;
            console.log($scope.employee);
        }).catch(function (err) {
            console.log(err);
        });


        $http.get(`/api/employees/employee-details/${$routeParams.id}/training`).then(function (result) {
            $scope.training = result.data;
        }).catch(function (err) {
            console.log(err);
        });

    }
]);