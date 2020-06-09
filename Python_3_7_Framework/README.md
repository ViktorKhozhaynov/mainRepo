### HOW TO SETUP THE PROJECT LOCALLY
To be able to run the tests locally several things have to be done first:

1) Install python3 (preferably 3.7 version), pip and virtualenv:

    - sudo apt-get update
    - sudo apt-get install python3.7
    - sudo apt install python3-pip
    - sudo pip3 install virtualenv

2) Create virtualenv and switch to editor. It's possible to create it either with Pycharm or:
    - virtualenv venv --python=/usr/bin/python3.7
    - source venv/bin/activate

3) Install dependencies:
    - pip install -r requirements.txt

4) Whatever IDE you're using you should set it to use the interpreter from the 'venv' you've just created

### HOW TO RUN THE TESTS
Finally the tests can be executed with:

    pytest --browser=['chrome', 'firefox'] --headless=True --remote=True
where:
 - browser argument ChromeDriver is used by default / optional
 - headless argument sets headless execution / optional
 - remote argument sets remote execution / optional

### DOCKER COMPOSE
Alternatively tests can be executed via docker-compose:
- docker-compose up --build

The command above does:
 - instanciates selenium hub
 - instanciates firefox and chrome nodes
 - builds auto-tests project
 - runs 'pytest --headless=True --remote=True --alluredir=allure/results'
 - creates allure report and hosts it on localhost:4446

 After everything is ready auto tests is executed and allure report is generated

 Allure report is served at localhost:4446
