import numpy as np
from matplotlib import pyplot as plt
from scipy.fft import fft, fftfreq

class FFT:

    SAMPLE_RATE = 150  # Hertz
    DURATION = 5  # Seconds
    N=SAMPLE_RATE * DURATION

    def generate_sine_wave(freq, sample_rate, duration):
        x = np.linspace(0, duration, sample_rate * duration, endpoint=False)
        frequencies = x * freq
        # 2pi because np.sin takes radians
        y = np.sin((2 * np.pi) * frequencies)
        return x, y

    # Generate a 2 hertz sine wave that lasts for 5 seconds
    x, y = generate_sine_wave(2, SAMPLE_RATE, DURATION)
    yf=fft(y)
    xf = fftfreq(N, 1/SAMPLE_RATE)
    plt.plot(xf, np.abs(yf))
    #plt.plot(x, y)
    plt.show()

