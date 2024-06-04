# При необходимости дополнительно установить Ingress-Nginx Controller
helm upgrade --install ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ingress-nginx --namespace ingress-nginx --create-namespace

или

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.10.1/deploy/static/provider/cloud/deploy.yaml


# Команды и результат
helm install hw9 k8s</br>
newman run HW9.postman_collection</br>
helm uninstall hw9

Результаты выполнения приложены в файле newman.png


# Описание архитектурного решения
В качестве паттерна для реализации идемпотентности использовался Idempotency Key
