starterControllers.controller('LatestCtrl', function ($scope, $location) {



  $scope.goCreateAnEvent = function () {
    $location.path('registration');
  }

  $scope.goHambaSafe = function () {
    $location.path('eventdetail');
  }
});
