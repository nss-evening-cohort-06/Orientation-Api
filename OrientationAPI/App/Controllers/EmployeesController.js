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

        $http.get("/api/employees/employee-details").then(function (result) {
            console.log($scope);
            $scope.employee = results.data;
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