starterControllers.controller('RatingCtrl', function ($scope) {
  $scope.event = {Name:"test",Description:"test1"}
  $scope.Rate=3;
  $scope.setRate = function(val){
    $scope.Rate = val;
  };
  
  console.log('Here');
});
