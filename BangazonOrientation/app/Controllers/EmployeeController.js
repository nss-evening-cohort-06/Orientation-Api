app.controller("EmployeeController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/employees/").then(function (result) {
            $scope.employees = result.data;
        });

       
        $scope.AddNewEmployee = () => {
            $location.path(`/employees/new`);
        };
    
    }
]);