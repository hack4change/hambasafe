starterControllers.controller('SearchCtrl', function ($scope) {
  //init
  (function () {
    $scope.shownGroup = null;
  })()
  $scope.searchEvents = function () {

  }
  $scope.eventType = ["Walk", "Run", "Cycle"];
  $scope.typeSelected = $scope.eventType[0];

  $scope.eventsToList = [
    {
      id: "andnadand",
      title: "FUCK",
      date: (new Date(Date.now())).toUTCString(),
      type: "Run",
      intensity: "Intense",
      location: "Far, far away",
      distance: "89km"
    }, {
      id: "edefsfsf",
      title: "Hey",
      date: (new Date(Date.now())).toUTCString(),
      type: "Cycle",
      intensity: "Beginner",
      location: "Claremont, Cape Town",
      distance: "2km"
    }
  ]
  $scope.toggleGroup = function (group) {
    if ($scope.isGroupShown(group)) {
      $scope.shownGroup = null;
    } else {
      $scope.shownGroup = group;
    }
  };
  $scope.selectedSearch = 0;
  $scope.toggleSelection = function (selected, group) {
    $scope.typeSelected = selected;
    $scope.toggleGroup(group);
  };

  $scope.isGroupShown = function (type, group) {
    return $scope.shownGroup === group && $scope.typeSelected !== type;
  };
  $scope.isShown = function (type, group) {
    return $scope.shownGroup === group && $scope.typeSelected !== type;
  };
  $scope.setActiveSearch = function (selection) {
    $scope.selectedSearch = selection;
  }
  $scope.activeSearch = function (selection) {
    return $scope.selectedSearch === selection;
  }
});
