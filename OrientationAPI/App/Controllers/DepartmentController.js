app.controller("DepartmentController", ["$scope", "$http",
    function ($scope, $http) {
        $scope.header = "Departments";

        $http.get("/api/departments").then(function (result) {
            $scope.departments = result.data;
        }).catch(function (err) {
            console.log(err);
        });
    }
]);