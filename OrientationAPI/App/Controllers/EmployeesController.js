app.controller("EmployeesController", ["$scope", "$http", "$location",
    function ($scope, $http, $location) {
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

        $hhtp.get("/api/employees/employee-details")

        $scope.navigateToCreateEmployee = function () {
            $location.path(`/CreateEmployee`);
        };

        $scope.navigateToEmployees = function () {
            $location.path('/employees');
        };

        $scope.employeeDetails = function () {
            $location.path('/employee-details');
        };

        
    }
]);