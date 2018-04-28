app.controller("ComputersController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/computers/").then(function (result) {
            $scope.computers = result.data;
        });

        $scope.computerDetail = (computerId) => {
            $location.path(`/computers/${computerId}`);
        };

        $scope.CreateNewComputer = () => {
            $location.path(`/computers/new`);
        };
    }
]);