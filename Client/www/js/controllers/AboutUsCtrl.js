starterControllers.controller('AboutUsCtrl', function ($scope) {

  $scope.$on('$ionicView.beforeEnter', function (event, viewData) {
    viewData.enableBack = true;
  });
});
