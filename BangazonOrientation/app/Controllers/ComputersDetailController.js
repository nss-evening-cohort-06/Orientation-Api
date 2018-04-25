app.controller("ComputersDetailController", ["$routeParams", "$scope", "$http",
    function ($routeParams, $scope, $http) {
        console.log($routeParams.id);
        $http.get(`/api/computers/${$routeParams.id}`).then(function (result) {
            $scope.computer = result.data;
        });

        /*  Given user is viewing a single computer
            When the user clicks on the Delete link
            Then the user should be presented with a screen to verify that it should be deleted
          And if the user chooses Yes from that screen, the computer should be deleted only if it is has never been assigned to an employee
    */
    }
]);