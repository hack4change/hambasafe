starterControllers.controller('RatingCtrl', function ($scope) {
  $scope.event = {Name:"Event Name",Description:"Description"}
  $scope.Rate=3;
  $scope.setRate = function(val){
    $scope.Rate = val;
  };

  console.log('Here');
});
