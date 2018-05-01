app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.refuse = false;

        $http.get(`/api/employees/${$routeParams.id}`).then(function (result) {
            $scope.employee = result.data;
        });

        $scope.back = () => {
            $location.path(`/employees`);
        };

        $scope.firstdelete = () => {

            $http.get(`/api/Employee/${$routeParams.id}`).then((employeeData) => {

                if (employeeData.data == null) {
                    return toDelete();
                }

                return $scope.refuse = true;
            });
        };

        const toDelete = () => {
            $location.path(`/employees/${$routeParams.id}/delete`);
        }

    }
]);