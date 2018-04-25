app.controller("NewComputersController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Computer) => {
            Computer.PurchaseDate = new Date(Computer.PurchaseDate);
            console.log(Computer);
        };
    }]);