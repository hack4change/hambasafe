starterControllers.controller('LatestCtrl', function ($scope, $location) {



  $scope.goCreateAnEvent = function () {
    $location.path('app/registration');
  }

  $scope.goHambaSafe = function () {
    $location.path('app/eventdetail/TEMP');
  }
});
