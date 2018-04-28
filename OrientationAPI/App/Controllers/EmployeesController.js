app.controller("EmployeesController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {
        $scope.header = "Employees";

        $http.get("/api/employees").then(function (result) {
            $scope.employees = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $scope.addEmployee = function () {
            $location.path(`/CreateEmployee`);
        }

        $scope.navigateToEmployees = function () {
            $location.path('/employees');
        }
    }
]);