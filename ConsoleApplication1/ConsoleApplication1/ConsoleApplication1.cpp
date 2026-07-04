#include <iostream>
#include <cstdio>
#include <algorithm>
#include <vector>

std::vector<int> Primes = std::vector<int>();

bool isPrime(int n) {
	if (n < 2) return false;
	for (int i = 2; i * i <= n; i++) {
		if (n % i == 0) return false;
	}
	return true;
}

int main() {
	int a, b;
	Primes.push_back(2);
	while (std::cin >> a >> b) {
		std::vector<int> results = std::vector<int>();
		for (int i = a; i <= b; i++) {
			if (i <= Primes.back()) {
				if (std::binary_search(Primes.begin(), Primes.end(), i)) {
					results.push_back(i);
				}
				continue;
			}
			if (isPrime(i)) {
				Primes.push_back(i);
				results.push_back(i);
			}
		}
		std::cout << results.size() << std::endl;
	}
}