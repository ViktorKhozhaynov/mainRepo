# CashOnGo Recruiting - TEST AUTOMATION ENGINEER

This is a test project within Cash On Go's technical recruiting process.

In doubt of technical issues you can send an e-mail with your questions.

## Preconditions

### Technical & Knowledge
You need at least:

* Experience in at least one programming language (PHP, Java, Python, etc.)
* Experience with testing frameworks and relevant libraries (Selenium, PHPUnit/JUnit, WebTest, etc.)
* A text editor (vim, nano, sublime text, notepad++) of your choice


### Assessment
You will be tested within the following areas of test automation development:

- Project structure
- Code readability
- Choosing the correct tools for the task
- Automating the execution of your tests
- Documenting of your work

## The tasks
Please create automated functional test for promotion code “5OFF” activation on Peachy main web page www.peachy.co.uk

Please make sure the project your create for this task is easy to (build and) execute in Linux environment.


### HOW TO RUN THE TESTS
To be able to run the test several things have to be done first:

1) Install python3 (preferably 3.7 version), pip and virtualenv:
    sudo apt-get update
    sudo apt-get install python3.7
    sudo apt install python3-pip
    sudo pip3 install virtualenv

2) Create virtualenv and switch to editor. It's possible to create it either with Pycharm or:
    virtualenv venv
    source venv/bin/activate

3) Install dependencies:
    pip install -r requirements.txt

Finally the tests can be executed with:
    pytest --browser=['chrome', 'firefox']
where browser argument is completely optional and ChromeDriver is used by default