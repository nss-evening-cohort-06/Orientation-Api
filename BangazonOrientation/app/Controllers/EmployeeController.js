app.controller("EmployeeController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/employees/").then(function (result) {
            $scope.employees = result.data;
        });

        $scope.employeesDetail = (employeeId) => {
            $location.path(`/employees/${employeeId}`);
        };

        $scope.AddNewEmployee = () => {
            $location.path(`/employees/new`);
        };
    }
]);