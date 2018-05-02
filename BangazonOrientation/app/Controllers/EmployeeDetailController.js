app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.hasComputer = true;
        $scope.edit = false;

        $http.get(`/api/employees/${$routeParams.id}/computer`).then((result) => {
            if (result.data.ComputerID === undefined)
                return $scope.hasComputer = false;
            $scope.employee = result.data;
        });

        $http.get('/api/computers/available').then((results) => {
            $scope.availableComputers = results.data;
        });

        $http.get('/api/employees/training').then((results) => {
            $scope.trainings = results.data;
        });

        $scope.back = () => {
            $location.path(`/employees`);
        };

        $scope.edits = () => {
            $scope.edit = true;
        }
    }
]);