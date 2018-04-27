app.controller("NewComputersController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Computer) => {

            $http.post("/api/computers/", Computer).then(function () {
                $location.path(`/computers`);
            }).catch((err) => {
                console.log("error posting new computer", err);
            });
        };
    }]);