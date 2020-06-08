FROM python:3.7-alpine

RUN apk add --no-cache unzip gcc musl-dev linux-headers
RUN apk --update add openjdk8

RUN wget -O allure-commandline.zip https://repo.maven.apache.org/maven2/io/qameta/allure/allure-commandline/2.13.0/allure-commandline-2.13.0.zip
RUN unzip allure-commandline.zip -d /allure
RUN rm allure-commandline.zip
ENV PATH="/allure/allure-2.13.0/bin:${PATH}"

WORKDIR /glarus_auto_tests

COPY requirements.txt requirements.txt
RUN pip install -r requirements.txt

COPY . .

CMD tail -f /dev/null
