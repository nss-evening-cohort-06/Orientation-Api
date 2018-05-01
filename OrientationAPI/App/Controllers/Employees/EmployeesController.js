app.controller("EmployeesController", ["$scope", "$http", "$location", "$routeParams",
    function ($scope, $http, $location, $routeParams) {
        $scope.header = "Employees";

        $http.get("/api/employees").then(function (result) {
            $scope.employees = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        }).catch(function (err) {
            console.log(err);
        });

        $scope.navigateToCreateEmployee = function () {
            $location.path(`/CreateEmployee`);
        };

        $scope.navigateToEmployees = function () {
            $location.path('/employees');
        };

        $scope.employeeDetails = function (employeeId) {
            $location.path(`/employee-details/${employeeId}`);
        };

        
    }
]);