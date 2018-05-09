app.controller("DepartmentsController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("api/departments/").then(function (result) {
            $scope.departments = result.data;
        });

        $scope.departmentDetail = (departmentId) => {
            $location.path(`/departments/${departmentId}`);
        };

        $scope.CreateNewDepartment = () => {
            $location.path(`/departments/new`);
        };
    }
]);