# Mahmoud Fadel Hahn Task
<div>
                <h2>Back end (API .Net Core 5)</h2>
  <h3>Projects </h3>
  <ul class="list-group">
    <li>Hahn.ApplicatonProcess.July2021.Web : Contains our 3 main API interfces (Authenticate,USer and Asset)</li>
                <li class="list-group-item">Hahn.ApplicatonProcess.July2021.Domain : Contains all domains logic and DTOs </li>
                <li class="list-group-item">Hahn.ApplicatonProcess.July2021.Data : Contains all repositories implementation and can be replaced to any DB provider</li>
                <li class="list-group-item">Hahn.ApplicatonProcess.July2021.Application : Contains all services serve on our 3 main API </li>
    <liHahn.XTest</li>
    <liHahn.Cache.Redis</li>
    </ul>
   <img width="300px" src="https://user-images.githubusercontent.com/6877794/142931520-0e44992c-2ef2-4d1d-9d92-1345afb74220.png">                
                <img width="300px" src="https://user-images.githubusercontent.com/6877794/142934291-01e57165-1749-4f1c-b712-89435dd93371.png">
   <img width="300px" src="https://user-images.githubusercontent.com/6877794/142938973-2bbafecd-515f-4d15-ba81-b422ed45f0e1.png">
</div>
              <h3>Projects Technologies </h3>
              <ul class="list-group">
                <li class="list-group-item">.Net Core 5</li>
                <li class="list-group-item">EF in memory database</li>
                <li class="list-group-item">DDD Domain desgin driven</li>
                <li class="list-group-item"> Cache Manager
                  <ul>
                    <li> Redis
                    </li>
                    <li> Memory
                    </li>
                  </ul>
                </li>
                <li class="list-group-item">Swashbuckle Swagger</li>
                <li class="list-group-item">Rest API (3)
                  <ul class="list-group">
                    <li class="list-group-item">Authenticate (Login and Register new users) </li>
                    <li class="list-group-item">User : Get User info with their tarcked assets and assign . </li>
                    <li class="list-group-item">Asset : Get all Assets from live service </li>
                  </ul>
                </li>
                <li class="list-group-item">serilog (file) </li>
                <li class="list-group-item">Jwt Bearer </li>
                <li class="list-group-item">Microsoft Identity : Used for Login and register new users</li>
                <li class="list-group-item">Xunit Testing : Used to test all API service using Xunit IOC</li>
                <li class="list-group-item">Auto Mapper</li>
                <li class="list-group-item">Clean Code</li>
                <li class="list-group-item">Docker</li>
              </ul>
              <div>  
            <h2> Aurelia</h2>            
            <p>User Can register , Login and check his profile then can select/deselect Assets.</p>
            <img src="https://user-images.githubusercontent.com/6877794/142912799-7edf5abc-20da-427b-bdb1-a04b0ba6ca60.png" />
            </div>
<ul class="list-group">
              <li>
                <h3>FE Pages </h3>
                <ul>
                  <li>Register <img  src="https://user-images.githubusercontent.com/6877794/142933649-51f582fe-9e9b-42d5-be3c-c9de4e8e24a4.png" />                  
</li>
                  <li>Login/Logout 
                    <img  src="https://user-images.githubusercontent.com/6877794/142933472-13faf580-91af-4ecc-98a3-7f2cb112904a.png" />                    
 </li>
                  <li>Track Assets 
                     <img  src="https://user-images.githubusercontent.com/6877794/142933972-2041d08c-ab81-4003-9bff-37215ff3bea3.png" />   
                  
</li>
                  <li>Check His Profile
                    <img  src="https://user-images.githubusercontent.com/6877794/142934090-2f4f86c1-2214-4cc2-b14c-811eb81f3eff.png" />                   
</li>
                </ul>
              </li>
  </ul>
   <h3>FE Projects Technologies </h3>
   <ul>
              <li class="list-group-item">aurelia-auth</li>
              <li class="list-group-item">aurelia-validation :Used to validate all registration form feilds .
                <img
                  src="https://user-images.githubusercontent.com/6877794/142915528-6adc18ee-67ad-4e05-88c6-e5841643bc40.png" />
              </li>
              <li class="list-group-item">aurelia-dialog : used to confirm user tracked assets :
                <img
                  src="https://user-images.githubusercontent.com/6877794/142915939-31c59f02-28ab-4ffa-aa1f-c11adcb111fe.png" />
              </li>
              <li class="list-group-item">aurelia-i18n : use localization file for all labels on site
                <img
                  src="https://user-images.githubusercontent.com/6877794/142916569-93766f4c-f35d-479d-a8a8-9ff71a5bce79.png" />
              </li>
              <li class="list-group-item">custom Attribute : used it to enable/disable register button on register form
                based on validation errors </li>
              <li class="list-group-item">Compose : used it to reuse asset component in profile and track pages
                <img
                  src="https://user-images.githubusercontent.com/6877794/142916404-c4efbcbc-6a5f-4f97-b4a9-9f87d3bb4d28.png" />
              </li>
            </ul>
