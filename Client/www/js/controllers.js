angular.module('starter.controllers', [])

.controller('SearchCtrl', function($scope) {
  (function(){
     
  })()
  /*
   * Calls the Events search function, with the value from the search bar and the 
   */
  $scope.search = function(){
    var query = document.querySelector('#searchBar').value;
    var filter = document.querySelector('#active');
    Events.search(query, filter)
  };
})
.controller('DashCtrl', function($scope) {})

.controller('ChatsCtrl', function($scope, Chats) {
  // With the new view caching in Ionic, Controllers are only called
  // when they are recreated or on app start, instead of every page change.
  // To listen for when this page is active (for example, to refresh data),
  // listen for the $ionicView.enter event:
  //
  //$scope.$on('$ionicView.enter', function(e) {
  //});

  $scope.chats = Chats.all();
  $scope.remove = function(chat) {
    Chats.remove(chat);
  };
})

.controller('ChatDetailCtrl', function($scope, $stateParams, Chats) {
  $scope.chat = Chats.get($stateParams.chatId);
})

.controller('AccountCtrl', function($scope) {
  $scope.settings = {
    enableFriends: true
  };
});
