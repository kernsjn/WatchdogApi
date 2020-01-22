docker build -t wgs-watchdog .

docker tag wgs-watchdog registry.heroku.com/wgs-watchdog/web

docker push registry.heroku.com/wgs-watchdog/web

heroku container:release web -a wgs-watchdog