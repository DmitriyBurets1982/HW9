# ��� ������������� ������������� ���������� Ingress-Nginx Controller
helm upgrade --install ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ingress-nginx --namespace ingress-nginx --create-namespace

���

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.10.1/deploy/static/provider/cloud/deploy.yaml


# ������� � ���������
helm install hw9 k8s
newman run HW9.postman_collection
helm uninstall hw9

���������� ���������� ��������� � ����� newman.png


# �������� �������������� �������
� �������� �������� ��� ���������� ��������������� ������������� Idempotency Key
