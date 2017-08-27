var app = angular.module('roomsApp', []);
app.controller('roomsController', function ($scope, $http) {

    var GetAllRooms = function () {
        $http.get("/api/Rooms/")
        .then(function (response) {
            $scope.rooms = response.data;
        });
    }

    $scope.showRooms = function () {
        $scope.show = 1;
    }

    $scope.hideRooms = function () {
        $scope.show = 0;
    }

    GetAllRooms();
});