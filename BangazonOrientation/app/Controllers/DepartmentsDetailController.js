app.controller("DepartmentsDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.departmentName = $routeParams.id;

        $http.get(`/api/departments/${$routeParams.id}`).then(function (result) {
            $scope.department = result.data;
        });

        $scope.back = () => {
            $location.path(`/departments`);
        };
    }
])