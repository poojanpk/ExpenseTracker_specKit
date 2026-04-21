const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? 'https://localhost:44365'

export class ApiError extends Error {
  public readonly status: number
  public readonly payload?: unknown

  constructor(message: string, status: number, payload?: unknown) {
    super(message)
    this.status = status
    this.payload = payload
  }
}

export async function apiRequest<T>(path: string, init?: RequestInit): Promise<T> {
  const response = await fetch(`${API_BASE_URL}${path}`, {
    headers: {
      'Content-Type': 'application/json',
      ...init?.headers,
    },
    ...init,
  })

  if (!response.ok) {
    const payload = await response.json().catch(() => undefined)
    throw new ApiError('Request failed', response.status, payload)
  }

  return response.json() as Promise<T>
}
