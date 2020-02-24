let app = new Vue({
    el : '#app',
    data : {       
        newUser : {
            Name : '',
            Surname : '',
            BirthDate : '',
            Email : '',
            PhoneNumber : ''
        },        
        users : [],
        message : '',
        homePage : true,
        userID : '',
        user: {}
    },
    methods : {        
    showUsers : function(){
        fetch('http://localhost:57816/api/users')
        .then(response => response.json())
            .then(response => {
                console.log(response)
                this.users = response ; 
                this.user = {};
                this.message = '';
            })
    },
   getUserByID : function(id){
        fetch('http://localhost:57816/api/users/' + id)
        .then(response => response.json())
            .then(response => {               
                this.user = response; 
    })
},
    editUser : function(id){       
        this.$http.put('http://localhost:57816/api/users/'+ id, this.user)
        .then(response => response.json())
        .then(response => {
            this.message = 'User updated !!'  
        })
    },
    createUser : function(){
        this.$http.post('http://localhost:57816/api/users', this.newUser)
        .then(response => {
            this.message = 'User created !!';        
        })
    },
    deleteUser : function(userId){
        this.$http.delete('http://localhost:57816/api/users/'+ userId)
        .then(response => response.json())
        .then(response => {
            this.message = 'User deleted !!'
        })
},
    homePageSetting : function(){
        this.homePage = !this.homePage;
        this.message = '';

        if (this.homePage)
            this.showUsers();
    },
    fillUserIDTodelete : function(id){
        this.userID = id;
    }
    },
created(){
     this.showUsers();
    }     
})