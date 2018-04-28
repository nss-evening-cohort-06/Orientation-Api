app.controller("EmployeesController", ["$scope", "$http", "$location", "EmployeeService",
    function ($scope, $http, $location, EmployeeService) {
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
        }

        $scope.navigateToEmployees = function () {
            $location.path('/employees');
        }

        //$scope.submitNewEmployee = function () {
        //    addEmployee($scope.employee);
        //    $location.path('/employees');
        //}
    }
]);