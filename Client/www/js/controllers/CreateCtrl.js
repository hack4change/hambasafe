starterControllers.controller('CreateCtrl', function ($scope, EventFactory) {
    //init
    (function(){
        $scope.shownGroup = null;
    })()


    $scope.searchEvents = function(){

      EventFactory.create(

        {id: 1},
        function (event) {
          $scope.eventData = event;
        },
        function (error) {

        });
    }
    $scope.eventType = ["Walk", "Run", "Cycle"]; //convert to array of objects
    $scope.typeSelected = $scope.eventType[0];

    $scope.toggleGroup = function(group) {
      if ($scope.isGroupShown(group)) {
        $scope.shownGroup = null;
      } else {
        $scope.shownGroup = group;
      }
    };
    $scope.toggleSelection = function(selected, group) {
      $scope.typeSelected = selected;
      $scope.toggleGroup(group);
    };

    $scope.isGroupShown = function(type, group) {
      return $scope.shownGroup === group && $scope.typeSelected !== type;
    };

    $scope.isShown = function(type, group) {
      return $scope.shownGroup === group && $scope.typeSelected !== type;
    };
  });