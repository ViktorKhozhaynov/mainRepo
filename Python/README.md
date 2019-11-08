### HOW TO RUN THE TESTS
To be able to run the test several things have to be done first:

1) Install python3 (preferably 3.7 version), pip and virtualenv:    
    sudo apt-get update    
    sudo apt-get install python3.7    
    sudo apt install python3-pip    
    sudo pip3 install virtualenv

2) Create virtualenv and switch to editor. It's possible to create it either with Pycharm or:    
    virtualenv venv --python=/usr/bin/python3.7    
    source venv/bin/activate

3) Install dependencies:
    pip install -r requirements.txt

Finally the tests can be executed with:
    pytest --browser=['chrome', 'firefox']
where browser argument is completely optional and ChromeDriver is used by default
